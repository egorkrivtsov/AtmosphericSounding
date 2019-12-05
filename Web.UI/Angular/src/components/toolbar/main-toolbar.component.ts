import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { IAppState } from 'core/store/state/app.state';
import { addTab, load } from '@app/store/actions';
import { ITab } from '@app/models';
import { sampleSize } from 'lodash';


@Component({
    selector: 'app-main-toolbar',
    templateUrl: './main-toolbar.component.html',
    styleUrls: ['./main-toolbar.component.less'],
})
export class MainToolbarComponent {
  constructor(private store: Store<IAppState>) {
  }

  public addTab = () => this.store.dispatch(addTab({ tab : { name: this.getRandomString(10)} as ITab }));


  public loadData = () => this.store.dispatch(load());


  private getRandomString = (length: number) => {
    const chars = 'abcdefghijklmnopqrstufwxyzABCDEFGHIJKLMNOPQRSTUFWXYZ1234567890';
    const name = sampleSize(chars, length || 12);
    return name.join('');
  }
}
