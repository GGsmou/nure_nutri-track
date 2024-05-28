import {
  Box,
  Button,
  Container,
  ThemeProvider,
  Typography,
  createTheme,
} from "@mui/material";
import { Link } from "react-router-dom";

const theme = createTheme({
  palette: {
    primary: { main: "#54BD95" },
  },
});

export const Landing = () => {
  return (
    <ThemeProvider theme={theme}>
      <div>
        <Box
          minHeight="100vh"
          sx={{
            background:
              "radial-gradient(circle, rgba(255,255,255,1) 0%, rgba(82,189,170,0.1) 100%)",
          }}
        >
          <header>
            <Container
              sx={{
                paddingTop: "20px",
                display: "flex",
                alignItems: "center",
                justifyContent: "space-between",
                width: "100%",
              }}
            >
              <Typography
                variant="h1"
                fontSize={50}
                fontWeight="bold"
                color="#54BD95"
              >
                NutriTrack
              </Typography>
              <Box
                sx={{
                  gap: 4,
                  display: "flex",
                }}
              >
                <Button
                  sx={{
                    color: "black",
                    textTransform: "none",
                  }}
                  size="large"
                >
                  Home
                </Button>
                <Button
                  sx={{
                    color: "black",
                    textTransform: "none",
                  }}
                  size="large"
                >
                  Download
                </Button>
                <Link to="/auth">
                  <Button
                    variant="contained"
                    color="primary"
                    sx={{
                      color: "white",
                      textTransform: "none",
                    }}
                    size="large"
                  >
                    Sign Up
                  </Button>
                </Link>
              </Box>
            </Container>
          </header>
        </Box>
      </div>
    </ThemeProvider>
  );
};
