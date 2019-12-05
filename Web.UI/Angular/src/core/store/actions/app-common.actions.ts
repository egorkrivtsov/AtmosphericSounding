import { createAction, props } from '@ngrx/store';
import { IUnprocessedData } from '@app/models';

export enum CommonActionTypes {
    CommonError = '[App Common Action] Common Error Occured',
}

export const errorOccured = createAction(CommonActionTypes.CommonError, props<{ userMessage: string, error: any}>());



