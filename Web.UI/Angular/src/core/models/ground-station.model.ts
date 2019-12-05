export interface IGroundStation {
    index: number;
    longitude: number;
    latitude: number;
    height: number;
    radarAboveStation?: number;
    onGroundPressure: number;
    onGroundWindVelocity: number;
    onGroundHumidityError: number;
    onGroundTemperatureError: number;
    dateTime: Date;
    nebulosityCode: string;
    radioZondType: number;
}
