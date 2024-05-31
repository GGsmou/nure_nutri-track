import { ReactNode, createContext } from "react";
import { Navigate } from "react-router-dom";
import { useCurrentUser } from "../features/useCurrentUser";
import { UserType } from "../types/User";

export const UserContext = createContext<UserType>({} as UserType);
// {
//   isLoading: false,
//   data: {
//     id: "1",
//     name: "John Doe",
//     role: "admin",
//     subscription: "t-3",
//     email: "123@gmail.com",
//     bannedIngredients: ["1", "2", "3"],
//     dailyCalories: 2000,
//     weight: 80,
//     desiredWeight: 70,

//     hydrated: true,
//     exercised: true,
//     ateHealthy: false,
//     chef: true,
//     critic: false,
//     criticTwoPointO: true,
//     social: true,
//   } as UserType,
// };
export const AuthFallback = ({ children }: { children: ReactNode }) => {
  const { isLoading, data } = useCurrentUser();

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (!data) {
    return <Navigate to="/auth" />;
  }

  return <UserContext.Provider value={data}>{children}</UserContext.Provider>;
};
