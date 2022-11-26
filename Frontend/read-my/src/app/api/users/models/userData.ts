export class UserData {
  public fullName: string;
  constructor(
    FullName: string,
    public role: 'Admin' | 'Project manager' | 'Worker',
    public name: string
  ) {
    this.fullName = FullName;
  }

  public get isAdmin() {
    return this.role === 'Admin';
  }

  public get isPM() {
    return this.role === 'Project manager';
  }

  public get isWorker() {
    return this.role === 'Worker';
  }
}
