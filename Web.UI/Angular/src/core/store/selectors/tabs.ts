import { createSelector } from '@ngrx/store';
import { IAppState, ITabsState } from '@app/store/state';

export const getTabsState = (store: IAppState) => store.tabsState;
export const getTabs = createSelector(getTabsState,
  (state: ITabsState) => state.tabs);

