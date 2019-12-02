import { createReducer, on } from '@ngrx/store';
import { addTab, removeTab  } from '../actions/tabs';
import { initialTabsState } from '../state/application.state';

export const TabReducer = createReducer(initialTabsState,
    on(addTab, (state, {tab}) => {
          const tabs = [ ...state.tabs ];
          tab.id = tabs.length + 1;
          tabs.push(tab);
          return { ...state, tabs };
    }),
    on(removeTab, (state, {id}) => {
      return { ...state};
}));
