import { KeyValuePair } from "./KeyValuePair";
import { Contact } from "./Contact";

export class Vehicle {
  public id: number;
  public model: KeyValuePair;
  public make: KeyValuePair;
  public isRegistered: boolean;
  public features: KeyValuePair[] = [];
  public contact: Contact;
  public LastUpdated: string;
}
