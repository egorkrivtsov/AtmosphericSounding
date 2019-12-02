import { Component } from '@angular/core';
import { Store } from '@ngrx/store';

import { IAppState } from '@app/store/state';
import { addTab } from '@app/store/actions';
import { ITab } from '@app/models';

@Component({
    selector: 'app-toolbar',
    templateUrl: './toolbar.html',
    styleUrls: ['./toolbar.less'],
})
export class ToolbarComponent {
  constructor(private store: Store<IAppState>) {
  }

  public createNewChart = () => {
    this.store.dispatch(addTab({ tab : { name: 'test1'} as ITab }));
  }
}
