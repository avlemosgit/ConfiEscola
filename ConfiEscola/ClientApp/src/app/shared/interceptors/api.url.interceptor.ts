import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Inject, Injectable, InjectionToken } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';
import { Router } from '@angular/router';

export const BASE_API_URL = new InjectionToken<string>('baseApiUrl');
export const AMBIENTE_PRODUCTION = new InjectionToken<string>('production');

@Injectable()
export class ApiUrlInterceptor implements HttpInterceptor {
    requisitions = 0;    

  constructor(@Inject(BASE_API_URL) private apiUrl: string,
    @Inject(AMBIENTE_PRODUCTION) private ambienteProducao: string, private router: Router) { }
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        
        console.log(req);

        this.requisitions++;
        const headersConfig = {
            'Accept': 'application/json',
            'Cache-Control': 'no-cache',
            'Pragma': 'no-cache',
            'x-requestid': this.newGuid(),
            'Authorization': ''
        };

        req = req.clone({ url: this.prepareUrl(req.url), setHeaders: headersConfig });

        return next.handle(req).pipe(catchError(err => {
            //var redirect = err.error && err.error.redirectTo ? err.error.redirectTo : '/error';
            //this.router.navigate([redirect]);
            return throwError(err);
        }), finalize(() => {
            this.requisitions--;
            // if (this.requisitions == 0)
            //     this.spinner.hide();
        }));
    }

     private prepareUrl(url: string): string {
         url = this.isAbsoluteUrl(url) || this.apiUrl === '/' ? url : this.apiUrl + '/' + url;
         return url.replace(/([^:]\/)\/+/g, '$1');
     }

    private isAbsoluteUrl(url: string): boolean {
        const absolutePattern = /^https?:\/\//i;
        return absolutePattern.test(url);
    }

    newGuid() {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            const r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }
}
