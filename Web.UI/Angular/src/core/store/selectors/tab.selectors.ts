import { createSelector } from '@ngrx/store';
import { IAppState  } from '../state/app.state';
import { ITabsState  } from '../state/tab.state';
import { ITab } from '@app/models';

export const getTabsState = (store: IAppState) => store.tabs;
export const getTabs = createSelector(getTabsState, (state: ITabsState) => state.tabs);
export const getTab = createSelector(getTabsState,
  (state: ITabsState, id: number) => state.tabs.find((tab: ITab) => tab.id === id));


