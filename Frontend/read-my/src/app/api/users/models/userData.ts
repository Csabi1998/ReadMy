export class UserData {
  public fullName: string;
  constructor(
    FullName: string,
    public role: 'Admin' | 'Project manager' | 'Worker',
    public name: string
  ) {
    this.fullName = FullName;
  }

  get isAdmin() {
    return this.role === 'Admin';
  }

  get isPM() {
    return this.role === 'Project manager';
  }

  get isWorker() {
    return this.role === 'Worker';
  }
}
