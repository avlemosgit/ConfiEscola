import { ApiUrlInterceptor, BASE_API_URL, AMBIENTE_PRODUCTION } from './interceptors/api.url.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { NgModule } from '@angular/core';

@NgModule({
    providers: [
        { provide: BASE_API_URL, useValue: environment.baseApiUrl },        
        { provide: AMBIENTE_PRODUCTION, useValue: environment.production },
        {
            provide: HTTP_INTERCEPTORS,
            useClass: ApiUrlInterceptor,
            multi: true
        }
    ]
})
export class ConfigurationModule {
}
