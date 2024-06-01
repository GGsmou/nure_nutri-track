import { useContext, useEffect } from "react";
import { Navigate, useSearchParams } from "react-router-dom";
import { UserContext } from "../components/Fallback";
import { useUsersCreate } from "../features/useUsersCreate";

const PAYMENT_LINK_T2 = "https://buy.stripe.com/test_dR6cPt0VVgwlaEU002";
const PAYMENT_LINK_T3 = "https://buy.stripe.com/test_8wM2aP0VV5RH4gw3cd";

export const Payment = () => {
  const [searchParams] = useSearchParams();
  const user = useContext(UserContext);
  const { mutate, isSuccess } = useUsersCreate({
    type: "edit",
    data: { id: user.id },
  });
  const tier = searchParams.get("tier") as "t-2" | "t-3" | undefined;
  const redirect = searchParams.get("redirect");
  const success = searchParams.get("success");

  useEffect(() => {
    if (success === "true" && tier && user.subscription !== tier) {
      mutate({ ...user, subscription: tier });
    }
  }, [mutate, success, tier, user]);

  if (!tier) {
    return <Navigate to="/" />;
  }

  if (redirect === "true") {
    switch (tier) {
      case "t-2":
        if (user.subscription === "t-1") {
          window.location.href = PAYMENT_LINK_T2;
          break;
        } else {
          return <Navigate to="/" />;
        }
      case "t-3":
        if (["t-1", "t-2"].includes(user.subscription)) {
          window.location.href = PAYMENT_LINK_T3;
          break;
        } else {
          return <Navigate to="/" />;
        }
    }
  }

  if (success === "true" && isSuccess) {
    return <Navigate to="/" />;
  }

  return <div>Loading...</div>;
};
