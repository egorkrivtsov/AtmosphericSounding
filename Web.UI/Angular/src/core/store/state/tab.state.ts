import { ITab } from '@app/models';

export interface ITabsState {
    tabs: ITab[];
    loading: boolean;
}

export const initialTabsState: ITabsState = {
    tabs: [],
    loading: false,
};