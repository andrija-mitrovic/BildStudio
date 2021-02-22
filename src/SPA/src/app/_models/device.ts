import { DevicePropertyValue } from "./devicePropertyValue";
import { DeviceType } from "./deviceType";

export interface Device {
    id: number;
    name: string;
    deviceTypeId: number;
    deviceType?: DeviceType;
    devicePropertyValues?: DevicePropertyValue[];
}
