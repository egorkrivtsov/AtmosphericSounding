import { Component, OnInit, Input } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { getData, isLoading } from '@app/store/selectors';
import { Observable } from 'rxjs';
import { IUnprocessedData } from '@app/models';
import { IAppState } from '@app/store/state';
import { partition, map } from 'rxjs/operators';
import { ChartDataSets, ChartOptions } from 'chart.js';
import { Color, Label } from 'ng2-charts';
import { marlData } from '@app/mocks';
import 'chartjs-plugin-zoom';

@Component({
    selector: 'app-data-chart-view',
    templateUrl: './data-chart-view.component.html',
    styleUrls: ['./data-chart-view.component.less'],
})
export class DataChartViewComponent implements OnInit {

    public data$: Observable<IUnprocessedData[]>;

    public isLoading$: Observable<boolean>;

    public x$: Observable<Label[]>;

    public y$: Observable<ChartDataSets[]>;


    @Input()
    public dataSet$: Observable<any>;

    public lineChartData: ChartDataSets[] = [
        { data: marlData.map(d => d.weight), label: 'Series A' },
      ];

    public lineChartLabels: Label[] = marlData.map(d => d.position);

    //   public lineChartOptions: (ChartOptions & { annotation: any }) = {
    //     responsive: true,
    //   };
    public lineChartOptions: (ChartOptions & { annotation: any }) = {
        responsive: true,
        plugins: {
            zoom: {
              pan: {
                enabled: true,
                mode: 'xy'
              },
              zoom: {
                enabled: true,
                mode: 'xy',
                // drag: true,
                 // speed: 10,
              }
            }
          },
        scales: {
          // We use this empty structure as a placeholder for dynamic theming.
          xAxes: [{}],
          yAxes: [
            {
              id: 'y-axis-0',
              position: 'left',
            }
          ]
        },
        annotation: {
          annotations: [
            {
              type: 'line',
              mode: 'vertical',
              scaleID: 'x-axis-0',
              value: 'March',
              borderColor: 'orange',
              borderWidth: 2,
              label: {
                enabled: true,
                fontColor: 'orange',
                content: 'LineAnno'
              }
            },
          ],
        },
      };


      public lineChartColors: Color[] = [
        {
          borderColor: 'black',
          backgroundColor: 'rgba(255,0,0,0.3)',
        },
      ];
      public lineChartLegend = true;
      public lineChartType = 'line';
      public lineChartPlugins = [];

      constructor(private store: Store<IAppState>) {
        this.data$ = this.store.pipe(select(getData));
        this.isLoading$ = this.store.pipe(select(isLoading));
        this.y$ = this.data$.pipe(map((d)=>{
          return  [{ data: d.map(tt => tt.weight), label: 'Series A' } as ChartDataSets];

        }));
        this.x$ = this.data$.pipe(map((d)=>d.map(tt => {
          return tt.position.toString() as Label;
        })));

        this.y$.subscribe(d=>{console.log(d)});
        this.x$.subscribe(d=> {console.log(d)});
      }

      ngOnInit() {
      }


}

