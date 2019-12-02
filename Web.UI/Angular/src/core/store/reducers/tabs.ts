import { createReducer, on } from '@ngrx/store';
import { addTab, removeTab, renameTab, moveTab  } from '../actions/tabs';
import { initialTabsState } from '../state/application';
import { remove } from 'lodash';
import { ITab } from '@app/models';


export const TabReducer = createReducer(initialTabsState,
    on(addTab, (state, {tab}) => {
      tab.id = state.tabs.length + 1;
      return { ...state, tabs: [...state.tabs, tab] };
    }),
    on(renameTab, (state, {id, name }) => {

      return { ...state };
    }),
    on(moveTab, (state, {oldIndex, newIndex }) => {

      return { ...state };
    }),
    on(removeTab, (state, {id}) => {
      const tabs: ITab[] = [...state.tabs];
      remove(tabs, (tab: ITab) => tab.id === id);
      return { ...state, tabs };
}));
