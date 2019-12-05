import { createReducer, on, Action } from '@ngrx/store';
import { load, loadSuccess  } from '../actions/data-source.actions';
import { IDataSourceState } from '../state';
import { initialUnprocessedDataSourceState } from '../state/data-soruce.state';

export const DataSourceReducer = createReducer<IDataSourceState, Action> (initialUnprocessedDataSourceState,
    on(load, (state) => {
      return { ...state, unprocessed: { ...state.unprocessed, loading: true }};
    }),
    on(loadSuccess, (state, {payload}) => {
      return { ...state,
        unprocessed: { ...state.unprocessed, items: payload, loading: false }};
    }));

