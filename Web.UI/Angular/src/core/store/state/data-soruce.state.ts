import { IUnprocessedData } from '@app/models';

export interface IDataItems<T> {
    items: T[];
    loading: boolean;
}

export interface IDataSourceState {
  unprocessed: IDataItems<IUnprocessedData>;
}

export const initialUnprocessedDataSourceState: IDataSourceState = {
  unprocessed: {
    items: [],
    loading: false,
  } as IDataItems<IUnprocessedData>
};


