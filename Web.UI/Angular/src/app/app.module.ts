import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';

/* material module */
import { MaterialModule } from './material.module';

/* Virtual scroller */
import { VirtualScrollerModule } from 'ngx-virtual-scroller';

/* components */
import { DataTableViewComponent } from '../components/data-table-view/data-table-view.component';
import { DataChartViewComponent } from '../components/data-chart-view/data-chart-view.component';
import { MainToolbarComponent } from '../components/toolbar/main-toolbar.component';
// charts
import { LineChartComponent } from '../components/charts/d3js/line-chart.component';
import { Ng2ChartComponent } from '../components/charts/ng2-charts/ng2-chart.component';
import { ChartsModule } from 'ng2-charts';
/* Services */

import { DataSourceService } from 'core/services';

/* Redux */
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { reducers  } from '@app/store/reducers';
import { effects  } from '@app/store/effects';

@NgModule({
  declarations: [
    AppComponent,
    DataTableViewComponent,
    DataChartViewComponent,
    LineChartComponent,
    Ng2ChartComponent,
    MainToolbarComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MaterialModule,
    ChartsModule,
    VirtualScrollerModule,
    /* StoreModule.forFeature(FeaturesKeys.Application, ApplicationReducer),
    StoreModule.forRoot([]), */
    StoreModule.forRoot(reducers),
    EffectsModule.forRoot(effects),
    StoreDevtoolsModule.instrument({maxAge: 25, logOnly: false }),
  ],
  providers: [DataSourceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
