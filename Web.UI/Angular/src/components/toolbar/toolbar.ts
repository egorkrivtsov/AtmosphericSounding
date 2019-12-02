import { Component } from '@angular/core';
import { Store, select } from '@ngrx/store';

import { IApplicationState } from '@app/store/state';
import { addTab } from '@app/store/actions';
import { ITab } from '@app/models';

@Component({
    selector: 'app-toolbar',
    templateUrl: './toolbar.html',
    styleUrls: ['./toolbar.less'],
})
export class ToolbarComponent {
  constructor(private store: Store<IApplicationState>) {
  }

  public createNewChart = () => {
    this.store.dispatch(addTab({ tab : { name: 'test1'} as ITab }));
  }
}
