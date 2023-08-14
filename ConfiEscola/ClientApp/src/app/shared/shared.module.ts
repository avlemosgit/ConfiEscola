import { NgModule } from '@angular/core';
import { CommonModule, NgFor } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ConfigurationModule } from './configuration.module';



@NgModule({
  declarations: [],
  imports: [   
        CommonModule,
        FormsModule,
        ReactiveFormsModule,        
        // ToastrModule.forRoot({   // ToastrModule added
        //     timeOut: 8000,
        //     preventDuplicates: true,
        //     progressBar: true,
        //     positionClass: 'toast-top-right'
        // }),
        // SweetAlert2Module.forRoot(),
        // ModalModule.forRoot(),
        ReactiveFormsModule,
        NgFor,
        ConfigurationModule,
  ],
  exports:[
    FormsModule,
    ReactiveFormsModule,
    ConfigurationModule,
  ]

})
export class SharedModule { }
