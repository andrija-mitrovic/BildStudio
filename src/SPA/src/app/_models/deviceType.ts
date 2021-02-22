import { Device } from "./device";

export interface DeviceType {
    id: number;
    name: string;
    parentId?: number;
    devices?: Device[];
}
