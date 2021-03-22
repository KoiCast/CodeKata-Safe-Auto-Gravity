import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FilesModule } from './modules/files/files.module';
import { FileService } from './services/file.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FilesModule
  ],
  providers: [FileService],
  bootstrap: [AppComponent]
})
export class AppModule { }
