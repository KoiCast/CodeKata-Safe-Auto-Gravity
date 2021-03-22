import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgxFileDropModule } from 'ngx-file-drop';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { ProcessFileComponent } from './process-file/process-file.component';

@NgModule({
  imports: [
    CommonModule,
    NgxFileDropModule,
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  declarations: [ProcessFileComponent],
  exports:[ProcessFileComponent]
})
export class FilesModule { }
