import {
  Box,
  Button,
  Divider,
  TextField,
  ThemeProvider,
  Typography,
  createTheme,
} from "@mui/material";
import { useAuthForm } from "../features/useAuthForm";
import { Google } from "@mui/icons-material";
import { useGoogleAuth } from "../features/useGoogleAuth";
const theme = createTheme({
  palette: {
    primary: { main: "#54BD95" },
  },
});

export const Auth = () => {
  const { fields, handlers } = useAuthForm();
  const googleAuth = useGoogleAuth();
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
              Create your account
            </Typography>
            <Box
              sx={{
                width: "100%",
                display: "flex",
                flexDirection: "column",
                gap: "20px",
              }}
            >
              <TextField {...fields.email} />
              <TextField type="password" {...fields.password} />
            </Box>
            <Box
              sx={{
                width: "100%",
                display: "flex",
                flexDirection: "column",
                gap: "20px",
                alignItems: "center",
              }}
            >
              <Box
                sx={{
                  display: "flex",
                  justifyContent: "space-between",
                  width: "100%",
                  gap: "40px",
                  height: "48px",
                }}
              >
                <Button
                  fullWidth
                  size="large"
                  variant="contained"
                  sx={{
                    color: "white",
                    textTransform: "none",
                    borderRadius: "20px",
                  }}
                  onClick={handlers.signIn}
                >
                  Sign In
                </Button>
                <Button
                  fullWidth
                  size="large"
                  variant="outlined"
                  sx={{
                    textTransform: "none",
                    borderRadius: "20px",
                  }}
                  onClick={handlers.signUp}
                >
                  Sign Up
                </Button>
              </Box>
              <Divider sx={{ width: "100%" }}>
                <Typography>OR</Typography>
              </Divider>
              <Box>
                <Button
                  startIcon={<Google />}
                  variant="outlined"
                  onClick={googleAuth}
                >
                  Google
                </Button>
              </Box>
            </Box>
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
              src="/nure_nutri-track/logo.png"
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
