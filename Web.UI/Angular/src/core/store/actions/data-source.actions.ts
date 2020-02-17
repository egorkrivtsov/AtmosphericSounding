import { createAction, props } from '@ngrx/store';
import { IUnprocessedData } from '@app/models';

export enum DataSourceActionTypes {
    Load = '[DataSource Action] Load Unprocessed',
    LoadSuccess = '[DataSource Action] Load Unprocessed Success',
}

export const load = createAction(DataSourceActionTypes.Load);

export const loadSuccess = createAction(DataSourceActionTypes.LoadSuccess, props<{payload: IUnprocessedData[]}>());


