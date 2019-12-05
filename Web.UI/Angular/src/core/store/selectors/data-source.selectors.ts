import { createSelector } from '@ngrx/store';
import { IAppState  } from '../state/app.state';
import { IDataSourceState } from '../state';

export const getDataSourceState = (store: IAppState) => store.dataSource;

export const getData = createSelector(getDataSourceState, (state: IDataSourceState) => state.unprocessed.items);
export const isLoading = createSelector(getDataSourceState, (state: IDataSourceState) => state.unprocessed.loading);

