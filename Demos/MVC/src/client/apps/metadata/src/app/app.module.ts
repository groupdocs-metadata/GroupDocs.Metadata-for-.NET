import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { MetadataModule } from "@groupdocs.examples.angular/metadata";

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule,
    MetadataModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
