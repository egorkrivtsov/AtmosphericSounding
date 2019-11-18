import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
/* material module */
import { MaterialModule } from './material.module';

import { VirtualScrollerModule } from 'ngx-virtual-scroller';
/* components */
import { DataTableViewComponent } from '../components/data-table-view/data-table-view';

@NgModule({
  declarations: [
    AppComponent,
    DataTableViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    VirtualScrollerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
