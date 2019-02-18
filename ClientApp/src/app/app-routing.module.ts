import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ResultsComponent } from './Results/results.component';
import { VoteComponent } from './Vote/vote.component';

const routes: Routes = [
  {
    path: '',
    component: ResultsComponent
  },
  {
    path: 'vote',
    component: VoteComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
