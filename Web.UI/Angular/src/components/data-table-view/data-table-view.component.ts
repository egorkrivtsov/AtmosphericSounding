import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { getData, isLoading } from '@app/store/selectors';
import { Observable } from 'rxjs';
import { IUnprocessedData } from '@app/models';
import { IAppState } from '@app/store/state';

@Component({
    selector: 'app-data-table-view',
    templateUrl: './data-table-view.component.html',
    styleUrls: ['./data-table-view.component.less'],
})
export class DataTableViewComponent implements OnInit {

  public data$: Observable<IUnprocessedData[]>;

  public isLoading$: Observable<boolean>;

  public displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];

  constructor(private store: Store<IAppState>) {
    this.data$ = this.store.pipe(select(getData));
    this.isLoading$ = this.store.pipe(select(isLoading));
  }
  public ngOnInit() { }
}

