import { Action, createAction, props } from '@ngrx/store';
import { ITab } from '@app/models';

/** User actions enum */
export enum UserActionTypes {
    AddTab = '[User Action] Add Tab',
    RemoveTab = '[User Action] Remove Tab',
}

export const addTab = createAction(UserActionTypes.AddTab, props<{tab: ITab }>());

export const removeTab = createAction(UserActionTypes.RemoveTab, props<{id: number | string }>());

