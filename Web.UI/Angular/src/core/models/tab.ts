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