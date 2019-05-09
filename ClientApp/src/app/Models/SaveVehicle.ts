import { Contact } from "./Contact"

export interface SaveVehicle {
  id: number;
  makeId: number;
  modelId: number;
  isRegistered: boolean;
  contact: Contact;
  featureIds: number[];
}
