import { useContext } from "react";
import { UserContext } from "../components/Fallback";
import { Button, Typography } from "@mui/material";
import { useLogout } from "../features/useLogout";

export const Home = () => {
  const currentUser = useContext(UserContext);
  const { mutateAsync: logout } = useLogout();
  return (
    <div>
      <Typography>Welcome to NutriTrack, {currentUser.name}</Typography>
      <Button onClick={() => logout()}>Logout</Button>
    </div>
  );
};
