import { ActionReducerMap } from '@ngrx/store';
import { IAppState } from 'core/store/state/app.state';
import { TabReducer } from './tab.reducers';
import { DataSourceReducer } from './data-source.reducers';


export const reducers: ActionReducerMap<IAppState> = {
    tabs: TabReducer,
    dataSource: DataSourceReducer,
  };
