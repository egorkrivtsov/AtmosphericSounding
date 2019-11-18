import { Component } from '@angular/core';
import { marlData } from '@app/mocks';

@Component({
    selector: 'app-data-table-view',
    templateUrl: './data-table-view.html',
    styleUrls: ['./data-table-view.less'],
})
export class DataTableViewComponent {
  constructor() {
  }

  public displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  public dataSource = marlData;
}
