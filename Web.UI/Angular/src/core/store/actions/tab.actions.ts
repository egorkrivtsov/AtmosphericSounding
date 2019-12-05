import { Action, createAction, props } from '@ngrx/store';
import { ITab } from '@app/models';

export enum TabActionTypes {
    Add = '[Tab Action] Add Tab',
    Remove = '[Tab Action] Remove Tab',
    Rename = '[Tab Action] Rename Tab',
    Move = '[Tab Action] Move Tab',
}

export const addTab = createAction(TabActionTypes.Add, props<{tab: ITab }>());

export const removeTab = createAction(TabActionTypes.Remove, props<{id: number | string }>());

export const renameTab = createAction(TabActionTypes.Rename, props<{id: number | string, name: string }>());

export const moveTab = createAction(TabActionTypes.Move, props<{oldIndex: number, newIndex: number }>());

