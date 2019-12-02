import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IAppState } from '@app/store/state';
import { getTabs } from '@app/store/selectors';
import { Store, select } from '@ngrx/store';
import { ITab } from '@app/models';
import { removeTab } from '@app/store/actions';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit {
  tabs$: Observable<ITab[]>;

  constructor(private store: Store<IAppState>) {
    this.tabs$ = this.store.pipe(select(getTabs));
  }

  ngOnInit() {
  }

  public remove = (id: number | string) => this.store.dispatch(removeTab({ id }));
}
