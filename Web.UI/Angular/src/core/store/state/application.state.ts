import { ITab } from '@app/models';

export interface IAppState {
    tabsState: ITabsState;
}

export interface ITabsState {
  tabs: ITab[];
  loading: boolean;
}

export const initialTabsState: ITabsState = {
  tabs: [],
  loading: false,
};
