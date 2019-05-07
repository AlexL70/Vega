import { Contact } from "./Contact"

export class SaveVehicle {
  public id: number;
  public makeId: number;
  public modelId: number;
  public osRegistered: boolean;
  public contact: Contact
  public featureIds: number[] = [];
}
