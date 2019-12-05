import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { ChartDataSets, ChartOptions } from 'chart.js';
import { Color, Label } from 'ng2-charts';
import { Observable } from 'rxjs';
import { marlData } from '@app/mocks';
import 'chartjs-plugin-zoom';


@Component({
    selector: 'app-ng2-chart',
    templateUrl: './ng2-chart.component.html',
    styleUrls: ['./ng2-chart.component.less']
})
export class Ng2ChartComponent implements OnInit {

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
                //drag: true,
                 //speed: 10,
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

      constructor() { }

      ngOnInit() {
      }

}
