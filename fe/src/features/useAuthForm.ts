import { yupResolver } from "@hookform/resolvers/yup";
import { useForm } from "react-hook-form";
import { useNavigate } from "react-router-dom";
import * as yup from "yup";
import { authService } from "../utils/authService";
import { useSignIn, useSignUp } from "./useAuth";

const AuthFormSchema = yup.object().shape({
  email: yup.string().email().required(),
  password: yup.string().min(8).required(),
});
type AuthFormType = yup.InferType<typeof AuthFormSchema>;

export const useAuthForm = () => {
  const navigate = useNavigate();
  const { mutateAsync: signIn } = useSignIn();
  const { mutateAsync: signUp } = useSignUp();
  const { formState, register, handleSubmit, setError } = useForm<AuthFormType>(
    {
      resolver: yupResolver(AuthFormSchema),
      mode: "onBlur",
      defaultValues: {
        email: "",
        password: "",
      },
    },
  );

  return {
    handlers: {
      signIn: handleSubmit(async (data) => {
        try {
          const authInfo = await signIn(data);
          authService.setAuthInfo(authInfo);
          navigate("/");
        } catch (e) {
          setError("email", { message: "Invalid email or password" });
          setError("password", { message: "Invalid email or password" });
        }
      }),
      signUp: handleSubmit(async (data) => {
        try {
          await signUp({ ...data, username: data.email });
          const authInfo = await signIn(data);
          authService.setAuthInfo(authInfo);
          navigate("/new-user");
        } catch (e) {
          setError("email", { message: "This email already in use" });
        }
      }),
    },
    fields: {
      email: {
        ...register("email"),
        error: !!formState.errors.email || false,
        label: formState.errors.email?.message || "Email",
      },
      password: {
        ...register("password"),
        error: !!formState.errors.password || false,
        label: formState.errors.password?.message || "Password",
      },
    },
  };
};
