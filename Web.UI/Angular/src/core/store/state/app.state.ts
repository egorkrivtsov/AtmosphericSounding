import { ITabsState } from './tab.state';
import { IDataSourceState } from './data-soruce.state';


export interface IAppState {
    tabs: ITabsState;
    dataSource: IDataSourceState;
}


