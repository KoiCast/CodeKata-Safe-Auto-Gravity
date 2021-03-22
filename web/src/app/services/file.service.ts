import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpErrorResponse } from '@angular/common/http';

@Injectable()
export class FileService {
  public baseurl = 'https://localhost:44343/api/file'
  constructor(private http: HttpClient) { }

  processfile(file, path){
    const formData = new FormData();
    formData.append('file', file, path);
    return this.http.post(this.baseurl + "/processfile", formData);
  }


}
