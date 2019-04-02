import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ResumeSummaryComponent } from './resume-summary/resume-summary.component';
import { UserEditorComponent } from './user-editor/user-editor.component';

const routes: Routes = [
  {path: '', redirectTo: 'index', pathMatch: 'full'},
  {path: 'index', component: ResumeSummaryComponent },
  {path: 'user', component: ResumeSummaryComponent },
  {path: 'user/job/:id', component: ResumeSummaryComponent},
  {path: 'user/techSkills/:id', component: ResumeSummaryComponent},
  {path: 'user/:id', component: UserEditorComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }