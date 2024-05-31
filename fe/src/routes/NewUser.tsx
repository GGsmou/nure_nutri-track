import {
  Box,
  Button,
  TextField,
  ThemeProvider,
  Typography,
  createTheme,
} from "@mui/material";
import { useForm } from "react-hook-form";
import { useNavigate } from "react-router-dom";
import { useUserGetById } from "../features/useUserGetById";
import { useUsersCreate } from "../features/useUsersCreate";
import { UserType } from "../types/User";
import { authService } from "../utils/authService";
import { getId } from "../utils/getId";

const theme = createTheme({
  palette: {
    primary: { main: "#54BD95" },
  },
});

export const NewUser = () => {
  const { data: user } = useUserGetById(authService.getAuthInfo().userId || "");
  const mutation = useUsersCreate({
    type: "create",
  });

  const navigate = useNavigate();

  const { handleSubmit, register, setError } = useForm<UserType>({
    defaultValues: {
      typeId: getId(),
      id: "",
      name: "",
      email: "",
      role: "user",
      subscription: "t-1",
      bannedIngredients: "" as unknown as [],
      dailyCalories: 0,
      weight: 80,
      desiredWeight: 80,
      hydrated: false,
      exercised: false,
      ateHealthy: false,
      chef: false,
      critic: false,
      criticTwoPointO: false,
      social: false,
    },
  });

  const handleCreate = handleSubmit((data) => {
    mutation
      .mutateAsync({
        ...data,
        typeId: getId(),
        id: user?.id || "",
        name: user?.userName || "",
        email: user?.email || "",
        bannedIngredients: [],
      })
      .then(() => {
        navigate("/");
      })
      .catch((err) => {
        setError("root", err.message);
      });
  });

  return (
    <ThemeProvider theme={theme}>
      <Box
        sx={{
          minHeight: "100vh",
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
          background:
            "linear-gradient(333deg, rgba(204,255,236,1) 0%, rgba(255,255,255,1) 35%, rgba(255,255,255,1) 65%, rgba(204,255,236,1) 100%)",
        }}
      >
        <Box
          sx={{
            width: "min(1100px, 80%)",
            height: "525px",
            bgcolor: "white",
            borderRadius: "20px",
            display: "flex",
            boxShadow: "10px 10px 33px -14px rgba(0,0,0,0.75);",
          }}
        >
          <Box
            sx={{
              width: "70%",
              display: "flex",
              justifyContent: "space-between",
              padding: "50px",
              alignItems: "center",
              flexDirection: "column",
              gap: "20px",
            }}
          >
            <Typography fontSize="48px" color="black">
              Few steps left
            </Typography>
            <Box
              sx={{
                display: "flex",
                flexDirection: "column",
                gap: "20px",
                width: "100%",
              }}
            >
              <TextField
                label="Daily Calories"
                placeholder="0"
                {...register("dailyCalories")}
                size="small"
                required
              />

              <TextField
                label="Weight"
                placeholder="0"
                {...register("weight")}
                size="small"
                required
              />
              <TextField
                label="Desired Weight"
                placeholder="0"
                {...register("desiredWeight")}
                size="small"
                required
              />
            </Box>

            <Button
              onClick={handleCreate}
              variant="contained"
              fullWidth
              size="large"
              sx={{
                textTransform: "none",
                color: "white",
                borderRadius: "20px",
                height: "48px",
              }}
            >
              Continue
            </Button>
          </Box>
          <Box
            sx={{
              width: "30%",
              bgcolor: "#85DAB9",
              borderTopRightRadius: "20px",
              borderBottomRightRadius: "20px",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              flexDirection: "column",
              gap: "20px",
            }}
          >
            <Typography variant="h4" color="white">
              Welcome to
            </Typography>
            <img
              src="/logo.png"
              alt="logo"
              style={{
                width: "140px",
                height: "140px",
                borderRadius: "50%",
              }}
            />
            <Typography variant="h2" fontWeight="500" color="white">
              NutriTrack
            </Typography>
          </Box>
        </Box>
      </Box>
    </ThemeProvider>
  );
};
