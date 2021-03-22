import { Component, OnInit } from '@angular/core';
import {NgxFileDropEntry, FileSystemFileEntry} from 'ngx-file-drop';
import { FileService } from 'src/app/services/file.service';
import { DriverReport } from 'src/app/models/driver-report';

@Component({
  selector: 'process-file',
  templateUrl: './process-file.component.html',
  styleUrls: ['./process-file.component.css']
})
export class ProcessFileComponent implements OnInit {

  public file: NgxFileDropEntry[]=[];
  public proccessedResults: DriverReport[];

  constructor(private fileService: FileService) { }

  ngOnInit() {
  }

  public dropped(files: NgxFileDropEntry[]) {
    this.file = files;
    for (const droppedFile of files) {

      // Is it a file?
      if (droppedFile.fileEntry.isFile) {
        const fileEntry = droppedFile.fileEntry as FileSystemFileEntry;
        fileEntry.file((file: File) => {
         this.fileService.processfile(file, droppedFile.relativePath).subscribe((res:any) =>{
           this.proccessedResults = new Array<DriverReport>();
           res.forEach(report => {
             this.proccessedResults.push(report);
           });
         })

        });
      } 
    }
  }

  public fileOver(event){
  }

  public fileLeave(event){
  }

}
