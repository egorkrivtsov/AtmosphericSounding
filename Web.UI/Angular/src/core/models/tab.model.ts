export interface ITab {
    id: number | string;
    name: string;
    type: TabType;
}

export enum TabType {
    RawData,
    ProcessedData,
    Chart
}

export class DataTab implements ITab {
    public id: string | number;

    public name: string;

    public type = TabType.RawData;

}