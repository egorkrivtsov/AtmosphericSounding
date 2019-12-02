import { ActionReducerMap } from '@ngrx/store';
import { IAppState } from '@app/store/state';
import { TabReducer } from './tabs';

/*
export enum FeaturesKeys {
    Application = 'Application',
}*/

export const reducers: ActionReducerMap<IAppState> = {
    tabsState: TabReducer
  };
