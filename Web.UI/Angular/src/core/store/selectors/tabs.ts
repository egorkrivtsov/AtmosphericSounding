import { createSelector } from '@ngrx/store';
import { IAppState, ITabsState } from '@app/store/state';
import { ITab } from '@app/models';

export const getTabsState = (store: IAppState) => store.tabsState;
export const getTabs = createSelector(getTabsState, (state: ITabsState) => state.tabs);
export const getTab = createSelector(getTabsState, 
  (state: ITabsState, id: number) => state.tabs.find((tab: ITab) => tab.id === id));

