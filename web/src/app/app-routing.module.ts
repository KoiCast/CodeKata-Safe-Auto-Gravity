import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes} from '@angular/router';
import { ProcessFileComponent } from './modules/files/process-file/process-file.component';

const routes: Routes = [
  { path: '', redirectTo: '/file', pathMatch: 'full' },
  {path:'file', component: ProcessFileComponent}
]

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
