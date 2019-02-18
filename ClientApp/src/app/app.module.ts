import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ResultsModule } from './Results/results.module';
import { VoteModule } from './Vote/vote.module';

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, HttpClientModule, AppRoutingModule, ResultsModule, VoteModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
