export interface LoginBody {
  email: string;
  password: string;
}

export interface RegisterBody {
  email: string;
  username: string;
  password: string;
}
export interface LoginResponse {
  token: string;
  userId: string;
}
