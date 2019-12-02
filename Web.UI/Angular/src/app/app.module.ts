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
import { ToolbarComponent } from '../components/toolbar/toolbar';
/* Redux */
import { StoreModule } from '@ngrx/store';
import { reducers  } from '@app/store/reducers';

@NgModule({
  declarations: [
    AppComponent,
    DataTableViewComponent,
    ToolbarComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    VirtualScrollerModule,
    /* StoreModule.forFeature(FeaturesKeys.Application, ApplicationReducer),
    StoreModule.forRoot([]), */
    StoreModule.forRoot(reducers),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
